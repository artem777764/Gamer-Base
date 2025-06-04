<script setup lang="ts">
import { onBeforeUnmount, onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import Review from '@/components/Review.vue';
import type { IGame } from '@/types/game';
import type { IReview } from '@/types/review';
import Card from '@/components/Card.vue';
import ReviewWriter from '@/components/ReviewWriter.vue';
import api from '@/lib/axios';

interface IVote {
    id: number,
    type: 'comment' | 'review',
    value: number,
}

const votes = ref<IVote[]>([])
const votesSent = ref(false)

const route = useRoute()
const id = route.params.id as string
const idNumber = Number(id)

const game = ref<IGame>()
async function fetchGameInfo(id: string)
{
    try {
        const response = await api.get(`/Games/${id}`)
        game.value = response.data
    } catch (error) {
        console.error('Ошибка при загрузке игры:', error);
    }
}

const reviews = ref<IReview[]>([])
async function fetchGameReviews(id: string)
{
    try {
        const response = await api.get(`/Games/Activity/${id}`, {
            withCredentials: true,
        })
        reviews.value = response.data
    } catch (error) {
        console.error('Ошибка при загрузке отзывов:', error);
    }
}

async function handleReviewCreated() {
    await fetchGameInfo(id)
    await fetchGameReviews(id)
}

async function handleCommentCreated() {
    await fetchGameReviews(id)
}

function handleVote(payload: { type: 'comment' | 'review', id: number, value: number }) {
    const existing = votes.value.find(v => v.id === payload.id && v.type === payload.type)
    if (existing) {
        existing.value = payload.value
    } else {
        votes.value.push(payload)
    }
}

onMounted(() => {
    fetchGameInfo(id)
    fetchGameReviews(id)

    window.addEventListener('beforeunload', handleUnload)
})

onBeforeUnmount(() => {
    window.removeEventListener('beforeunload', handleUnload)
    if (!votesSent.value) {
        sendVotes()
        votesSent.value = true
    }
})

function handleUnload(event: BeforeUnloadEvent) {
    if (votes.value.length === 0 || votesSent.value) return;

    const mappedVotes = votes.value.map(v => ({
        entityId: v.id,
        type: v.type,
        mark: v.value,
    }));

    const blob = new Blob([JSON.stringify(mappedVotes)], { type: 'application/json' });

    navigator.sendBeacon("http://localhost:5007/Vote", blob);
}

async function sendVotes() {
    if (votes.value.length === 0) return;

    const mappedVotes = votes.value.map(v => ({
        entityId: v.id,
        type: v.type,
        mark: v.value,
    }));

    api.post("/Vote", mappedVotes)
}
</script>

<template>
    <div class="min-h-screen bg-background px-5 pt-5">
        <p class="font-russo leading-none text-shadow text-white text-5xl text-justify">{{game?.Name}}</p>
        <div class="flex flex-row gap-5 mt-5">
            <div v-if="game" class="w-1/4 flex-shrink-0">
                <div>
                    <Card :image-src="game.ImageURL"/>
                </div>
                <div>
                    <p v-if="game.Rating" class="font-russo leading-none text-shadow text-white text-3xl mt-1 text-center">{{ game.Rating?.toFixed(2) }}/5.00</p>
                    <p v-else class="font-russo leading-none text-shadow text-white text-3xl mt-1 text-center">Отзывов нет</p>
                    <router-link :to="{ name: 'GameInfo' }">
                        <p class="font-russo leading-none text-shadow text-white text-3xl underline mt-1 text-center">Информация</p>
                    </router-link>
                </div>
            </div>
            <div class="flex flex-col gap-5 w-full">
                <ReviewWriter @review-created="handleReviewCreated" :game-id="idNumber"/>
                <div class="w-full flex flex-col gap-5">
                    <Review @comment-created="handleCommentCreated" @vote="handleVote" v-for="review in reviews" :key="review.ReviewId" :review="review"></Review>
                </div>
            </div>
        </div>
    </div>
</template>