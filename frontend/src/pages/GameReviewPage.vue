<script setup lang="ts">
import { onMounted, ref } from 'vue';
import axios from 'axios'
import { useRoute } from 'vue-router';
import Review from '@/components/Review.vue';
import type { IGame } from '@/types/game';
import type { IReview } from '@/types/review';
import Card from '@/components/Card.vue';
import ReviewWriter from '@/components/ReviewWriter.vue';

const route = useRoute()
const id = route.params.id as string
const idNumber = Number(id)

const game = ref<IGame>()
async function fetchGameInfo(id: string)
{
    try {
        const response = await axios.get(`http://localhost:5007/Games/${id}`)
        game.value = response.data
    } catch (error) {
        console.error('Ошибка при загрузке игры:', error);
    }
}

const reviews = ref<IReview[]>([])
async function fetchGameReviews(id: string)
{
    try {
        const response = await axios.get(`http://localhost:5007/Games/Activity/${id}`)
        reviews.value = response.data
    } catch (error) {
        console.error('Ошибка при загрузке отзывов:', error);
    }
}

onMounted(() => {
    fetchGameInfo(id)
    fetchGameReviews(id)
})
</script>

<template>
    <div class="min-h-screen bg-background px-5 pt-5">
        <p class="font-russo leading-none text-shadow text-white text-5xl text-justify">{{game?.Name}}</p>
        <div class="flex flex-row gap-5 mt-5">
            <div v-if="game" class="w-1/4 flex-shrink-0">
                <div>
                    <Card :image-src="game.ImageURL"/>
                </div>
                <router-link v-if="game.Rating" :to="{ name: 'GameInfo' }">
                    <p class="font-russo leading-none text-shadow text-white text-3xl underline mt-1 text-center">Информация</p>
                </router-link>
            </div>
            <div class="flex flex-col gap-5">
                <ReviewWriter :game-id="idNumber"/>
                <div class="w-full flex flex-col gap-5">
                    <Review v-for="review in reviews" :key="review.ReviewId" :review="review"></Review>
                </div>
            </div>
        </div>
    </div>
</template>