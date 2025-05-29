<script setup lang="ts">
import type { IReview } from '@/types/review';
import Card from '@/components/Card.vue';
import Comment from '@/components/Comment.vue'
import { ref } from 'vue';

defineProps<{
    review: IReview
}>()

const commentsIsOpen = ref(false)

function handleComments() {
    commentsIsOpen.value = !commentsIsOpen.value
}
</script>

<template>
    <div class="p-5 bg-secondary flex flex-col gap-3 rounded shadow-md">
        <div class="flex flex-row place-content-between">
            <div class="flex flex-row gap-2 items-center">
                <Card :image-src="review.UserImageURL" aspect='aspect-[1/1]' class="w-[54px]"/>
                <div class="flex flex-col gap-2">
                    <p class="font-russo leading-none text-shadow text-lg, text-white">{{ review.UserName }}</p>
                    <p class="font-russo leading-none text-shadow text-base text-white">{{ review.Mark.toFixed(2) }}/5.00</p>
                </div>
            </div>
            <div>
                <p class="font-russo leading-none text-shadow text-white">{{ review.Rating }}</p>
            </div>
        </div>
        <div class="flex flex-col gap-2">
            <p class="font-russo leading-none text-shadow text-xl text-white text-justify">{{ review.Title }}</p>
            <p class="font-russo leading-none text-shadow text-base text-white text-justify">{{ review.Content }}</p>
        </div>
        <p @click="handleComments" class="font-russo leading-none text-shadow text-base text-white hover:cursor-pointer text-right">Комментарии</p>
        <div v-if="commentsIsOpen" class="bg-background flex flex-col divide-y divide-primary">
            <Comment v-for="comment in review.Comments" :key="comment.Id" :comment="comment"/>
        </div>
    </div>
</template>