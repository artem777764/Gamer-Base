<script setup lang="ts">
import type { IComment } from '@/types/comment';
import Card from '@/components/Card.vue';
import Vote from '@/components/Vote.vue';

defineProps<{
    comment: IComment
}>()

const emit = defineEmits<{
  (e: 'vote', payload: { type: 'comment' | 'review', id: number, value: number }): void
}>()

function handleVote(payload: { type: 'comment' | 'review', id: number, value: number }) {
  emit('vote', payload)
}
</script>

<template>
    <div class="p-5 flex flex-col gap-3">
        <div class="flex flex-row place-content-between">
            <div class="flex flex-row gap-2 items-center">
                <Card :image-src="comment.UserImageURL" aspect='aspect-[1/1]' class="w-[50px]"/>
                <div class="flex flex-col gap-2">
                    <p class="font-russo leading-none text-shadow text-lg, text-white">{{ comment.UserName }}</p>
                    <p v-if="comment.UserMark" class="font-russo leading-none text-shadow text-base text-white">{{ comment.UserMark.toFixed(2) }}/5.00</p>
                    <p v-else class="font-russo leading-none text-shadow text-base text-white">Оценки нет</p>
                </div>
            </div>
            <Vote @vote="handleVote" :id="comment.Id" type="comment" :rating="comment.Rating" :current-mark="comment.UserRatingMark"/>
        </div>
        <div class="flex flex-col gap-2">
            <p class="font-russo leading-none text-shadow text-base text-white text-justify">{{ comment.Content }}</p>
        </div>
    </div>
</template>